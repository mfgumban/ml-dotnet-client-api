xquery version "1.0-ml";

declare option xdmp:mapping "false";
declare option xdmp:commit "explicit";

declare variable $id as xs:string external;
declare variable $itemName as xs:string external;
declare variable $session as xs:string external;

let $uri := fn:concat("/test/insertMaster/", $id, ".json")
return (
  xdmp:node-insert-child(
    fn:doc($uri)/object-node()/array-node("items"),
    object-node {
      "itemName": $itemName
    }),
  xdmp:commit(),
  fn:doc($uri))