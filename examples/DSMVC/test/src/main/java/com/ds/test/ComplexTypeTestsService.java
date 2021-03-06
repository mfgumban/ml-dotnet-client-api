package com.ds.test;

// IMPORTANT: Do not edit. This file is generated.

import com.marklogic.client.io.Format;
import java.io.Reader;
import java.io.InputStream;


import com.marklogic.client.DatabaseClient;

import com.marklogic.client.impl.BaseProxy;

/**
 * API endpoints to test complex data types.
 */
public interface ComplexTypeTestsService {
    /**
     * Creates a ComplexTypeTestsService object for executing operations on the database server.
     *
     * The DatabaseClientFactory class can create the DatabaseClient parameter. A single
     * client object can be used for any number of requests and in multiple threads.
     *
     * @param db	provides a client for communicating with the database server
     * @return	an object for session state
     */
    static ComplexTypeTestsService on(DatabaseClient db) {
        final class ComplexTypeTestsServiceImpl implements ComplexTypeTestsService {
            private BaseProxy baseProxy;

            private ComplexTypeTestsServiceImpl(DatabaseClient dbClient) {
                baseProxy = new BaseProxy(dbClient, "/test/complex/");
            }

            @Override
            public Reader returnJsonDoc(Reader value) {
              return BaseProxy.JsonDocumentType.toReader(
                baseProxy
                .request("returnJsonDoc.xqy", BaseProxy.ParameterValuesKind.SINGLE_NODE)
                .withSession()
                .withParams(
                    BaseProxy.documentParam("value", false, BaseProxy.JsonDocumentType.fromReader(value)))
                .withMethod("POST")
                .responseSingle(false, Format.JSON)
                );
            }


            @Override
            public InputStream returnBinary(InputStream value) {
              return BaseProxy.BinaryDocumentType.toInputStream(
                baseProxy
                .request("returnBinary.xqy", BaseProxy.ParameterValuesKind.SINGLE_NODE)
                .withSession()
                .withParams(
                    BaseProxy.documentParam("value", false, BaseProxy.BinaryDocumentType.fromInputStream(value)))
                .withMethod("POST")
                .responseSingle(false, Format.BINARY)
                );
            }


            @Override
            public Reader returnXmlDoc(Reader value) {
              return BaseProxy.XmlDocumentType.toReader(
                baseProxy
                .request("returnXmlDoc.xqy", BaseProxy.ParameterValuesKind.SINGLE_NODE)
                .withSession()
                .withParams(
                    BaseProxy.documentParam("value", false, BaseProxy.XmlDocumentType.fromReader(value)))
                .withMethod("POST")
                .responseSingle(false, Format.XML)
                );
            }


            @Override
            public Reader returnArray(Reader value) {
              return BaseProxy.ArrayType.toReader(
                baseProxy
                .request("returnArray.xqy", BaseProxy.ParameterValuesKind.SINGLE_NODE)
                .withSession()
                .withParams(
                    BaseProxy.documentParam("value", false, BaseProxy.ArrayType.fromReader(value)))
                .withMethod("POST")
                .responseSingle(false, Format.JSON)
                );
            }


            @Override
            public Reader returnObjectNode(Reader value) {
              return BaseProxy.ObjectType.toReader(
                baseProxy
                .request("returnObject.xqy", BaseProxy.ParameterValuesKind.SINGLE_NODE)
                .withSession()
                .withParams(
                    BaseProxy.documentParam("value", false, BaseProxy.ObjectType.fromReader(value)))
                .withMethod("POST")
                .responseSingle(false, Format.JSON)
                );
            }


            @Override
            public Reader returnTextDoc(Reader value) {
              return BaseProxy.TextDocumentType.toReader(
                baseProxy
                .request("returnTextDoc.xqy", BaseProxy.ParameterValuesKind.SINGLE_NODE)
                .withSession()
                .withParams(
                    BaseProxy.documentParam("value", false, BaseProxy.TextDocumentType.fromReader(value)))
                .withMethod("POST")
                .responseSingle(false, Format.TEXT)
                );
            }

        }

        return new ComplexTypeTestsServiceImpl(db);
    }

  /**
   * Accepts and returns a JSON document.
   *
   * @param value	provides input
   * @return	as output
   */
    Reader returnJsonDoc(Reader value);

  /**
   * Accepts and returns a binary.
   *
   * @param value	provides input
   * @return	as output
   */
    InputStream returnBinary(InputStream value);

  /**
   * Accepts and returns an XML document.
   *
   * @param value	provides input
   * @return	as output
   */
    Reader returnXmlDoc(Reader value);

  /**
   * Accepts and returns a (JSON) array.
   *
   * @param value	provides input
   * @return	as output
   */
    Reader returnArray(Reader value);

  /**
   * Accepts and returns a (JSON) object.
   *
   * @param value	provides input
   * @return	as output
   */
    Reader returnObjectNode(Reader value);

  /**
   * Accepts and returns a text document.
   *
   * @param value	provides input
   * @return	as output
   */
    Reader returnTextDoc(Reader value);

}
