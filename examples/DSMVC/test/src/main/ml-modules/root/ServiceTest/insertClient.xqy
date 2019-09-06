xquery version "1.0-ml";

declare option xdmp:mapping "false";


declare variable $fname as xs:string external;
declare variable $lname as xs:string external;
declare variable $adresse as xs:string external;
declare variable $gender as xs:string external;

let $id := sem:uuid-string()
let $uri := fn:concat("/test/insertClient/", $id, ".json")
let $doc := object-node {
  "id": $id,
  "name": $fname,
  "lastName":$lname,
  "Adresse":$adresse,
  "Gender":$gender
}

return (
  xdmp:document-insert($uri, $doc), 
  $id
)