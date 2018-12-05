xquery version "1.0-ml";

import module namespace search = "http://marklogic.com/appservices/search" at "/MarkLogic/appservices/search/search.xqy";

declare variable $pageLength as xs:int external;
declare variable $options as xs:string* external;
declare variable $doc as node() external;
declare option xdmp:mapping "false";

(
  fn:concat("pageLength: ", $pageLength),
  for $option at $pos in $options return fn:concat("options (", $pos, "): ", $option),
  fn:concat("doc: ", xdmp:quote($doc))
)