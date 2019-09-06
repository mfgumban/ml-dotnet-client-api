xquery version "1.0-ml";

declare option xdmp:mapping "false";


declare variable $Id as xs:string external;



let $uri := fn:concat("/test/insertClient/", $Id, ".json")


return (
 xdmp:document-delete($uri)
)