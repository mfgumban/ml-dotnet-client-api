xquery version "1.0-ml";

declare variable $value1 as xs:string external;
declare variable $value2 as xs:int external;
declare variable $value3 as xs:dateTime external;
declare option xdmp:mapping "false";

let $newline := "&#10;"
return fn:concat($value1, $newline, $value2, $newline, $value3)