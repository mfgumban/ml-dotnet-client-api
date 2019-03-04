using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MarkLogic.Client.DataService.CodeGen
{
    internal class ServiceCSharp
    {
        private const string DataServiceBaseClassName = "DataServiceBase";
        private const string DatabaseClientInterface = "IDatabaseClient";

        public static void Generate(Service serviceDecl, Endpoint[] endpointDecls, TextWriter output)
        {
            // TODO: validate inputs

            var cu = SyntaxFactory.CompilationUnit();
            var nsDecl = GenerateNamespace(serviceDecl);
            nsDecl.WithMembers(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(GenerateClass(serviceDecl, endpointDecls)));
            cu.WithMembers(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(nsDecl));
            cu.NormalizeWhitespace();
            cu.WriteTo(output);
        }

        private static NamespaceDeclarationSyntax GenerateNamespace(Service serviceDecl)
        {
            Debug.Assert(serviceDecl != null);
            var nsTokens = serviceDecl.NamespaceTokens;
            Debug.Assert(nsTokens != null);
            Debug.Assert(nsTokens.Length > 0);

            var syntax = new Stack<NameSyntax>(nsTokens.Select(n => SyntaxFactory.IdentifierName(n)).Reverse());
            while (syntax.Count > 1)
            {
                var left = syntax.Pop();
                var right = syntax.Pop();
                Debug.Assert(right is SimpleNameSyntax); // right should always be an IdentifierNameSyntax
                syntax.Push(SyntaxFactory.QualifiedName(left, (SimpleNameSyntax)right));
            }
            return SyntaxFactory.NamespaceDeclaration(syntax.Pop());
        }

        private static ClassDeclarationSyntax GenerateClass(Service serviceDecl, Endpoint[] endpointDecls)
        {
            Debug.Assert(serviceDecl != null);

            var cd = SyntaxFactory.ClassDeclaration(serviceDecl.ClassName)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                    SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(DataServiceBaseClassName)))));

            var classMembers = new List<MemberDeclarationSyntax>(new MemberDeclarationSyntax[] 
            {
                GenerateConstructor(serviceDecl),
                GenerateCreateMethod(serviceDecl)
            });
            classMembers.AddRange(endpointDecls.Select(e => GenerateEndpointMethod(e)));
            cd.WithMembers(SyntaxFactory.List(classMembers));

            return cd;
        }

        private static ConstructorDeclarationSyntax GenerateConstructor(Service serviceDecl)
        {
            Debug.Assert(serviceDecl != null);

            const string DbClientVarName = "dbClient";

            var cd = SyntaxFactory.ConstructorDeclaration(SyntaxFactory.Identifier(serviceDecl.ClassName))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword)))
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier(DbClientVarName))
                        .WithType(SyntaxFactory.IdentifierName(DatabaseClientInterface)))))
                .WithInitializer(SyntaxFactory.ConstructorInitializer(
                    SyntaxKind.BaseConstructorInitializer,
                    SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>(new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.Argument(SyntaxFactory.IdentifierName(DbClientVarName)),
                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                        SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal(serviceDecl.EndpointDirectory)))
                    }))))
                .WithBody(SyntaxFactory.Block());

            return cd;
        }

        private static MethodDeclarationSyntax GenerateCreateMethod(Service serviceDecl)
        {
            Debug.Assert(serviceDecl != null);

            const string DbClientVarName = "dbClient";

            var md = SyntaxFactory.MethodDeclaration(SyntaxFactory.IdentifierName(serviceDecl.ClassName), SyntaxFactory.Identifier("Create"))
                .WithModifiers(SyntaxFactory.TokenList(new[]
                {
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.StaticKeyword)
                }))
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier(DbClientVarName))
                        .WithType(SyntaxFactory.IdentifierName(DatabaseClientInterface)))))
                .WithBody(SyntaxFactory.Block(SyntaxFactory.SingletonList<StatementSyntax>(
                    SyntaxFactory.ReturnStatement(
                        SyntaxFactory.ObjectCreationExpression(
                            SyntaxFactory.IdentifierName(serviceDecl.ClassName))
                        .WithArgumentList(SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName(DbClientVarName)))))))));

            return md;
        }

        private static MethodDeclarationSyntax GenerateEndpointMethod(Endpoint endpointDecl)
        {
            Debug.Assert(endpointDecl != null);

            var md = SyntaxFactory.MethodDeclaration(SyntaxFactory.GenericName(SyntaxFactory.Factory.Identifier("Task"))
                )
        }
    }
}
