declare option xdmp:mapping "false";


declare variable $fid as xs:string external;

let $id1 := sem:uuid-string()
let $n:=fn:concat("/test/insertClient/",$fid,".json")

return (
 fn:doc($n)
)