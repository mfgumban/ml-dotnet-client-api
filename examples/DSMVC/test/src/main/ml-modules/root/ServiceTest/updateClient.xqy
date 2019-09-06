xquery version "1.0-ml";

declare option xdmp:mapping "false";

declare variable $Id as xs:string external;
declare variable $fname as xs:string external;
declare variable $lname as xs:string external;
declare variable $adresse as xs:string external;
declare variable $gender as xs:string external;


let $uri := fn:concat("/test/insertClient/", $Id, ".json")
let $doc := object-node {
  "id": $Id,
  "name": $fname,
  "lastName":$lname,
  "Adresse":$adresse,
  "Gender":$gender
}

return (
  xdmp:document-insert($uri, $doc), 
  $Id
)