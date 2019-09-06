xquery version "1.0-ml";

declare option xdmp:mapping "false";

let $id := sem:uuid-string()

return (
  json:to-array(fn:doc())
)