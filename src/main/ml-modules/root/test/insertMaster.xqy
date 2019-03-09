xquery version "1.0-ml";

declare option xdmp:mapping "false";
declare option xdmp:commit "explicit";

declare variable $name as xs:string external;
declare variable $session as xs:string external;

let $id := sem:uuid-string()
let $uri := fn:concat("/test/insertMaster/", $id, ".json")
let $doc := object-node {
  "id": $id,
  "name": $name,
  "items": array-node { }
}

return (
  xdmp:document-insert($uri, $doc), 
  $id
)