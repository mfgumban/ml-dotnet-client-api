xquery version "1.0-ml";

(: Note: xs:int is a signed 32-bit integer, whilst xs:integer is unbounded :)
declare variable $value as xs:int external;
declare option xdmp:mapping "false";

$value