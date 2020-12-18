'use strict';

var a;
var b;
var c;
var d;

// return total number of null parameters
[a, b, c, d].reduce((total, v) => total + (v == null ? 1 : 0), 0);
