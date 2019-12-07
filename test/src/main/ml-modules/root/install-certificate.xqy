xquery version "1.0-ml";
import module namespace pki = "http://marklogic.com/xdmp/pki" at "/MarkLogic/pki.xqy";
import module namespace admin = "http://marklogic.com/xdmp/admin" at "/MarkLogic/admin.xqy";

let $templateid := pki:template-get-id(pki:get-template-by-name("ml-dotnet-client-api-tests-template"))

(: Path on the MarkLogic host that is readable by the MarkLogic server process (default daemon) :)
let $path-to-cert := "/tmp/cert/marklogic.pem"
let $path-to-key := "/tmp/cert/marklogic.key"

return
pki:insert-host-certificate($templateid,
  xdmp:document-get($path-to-cert,
    <options xmlns="xdmp:document-get"><format>text</format></options>),
  xdmp:document-get($path-to-key,
    <options xmlns="xdmp:document-get"><format>text</format></options>)
)