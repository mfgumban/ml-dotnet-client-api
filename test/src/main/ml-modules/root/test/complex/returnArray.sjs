'use strict';

var value;

if (value != null) {
  const isArrayNode = value instanceof Node && value.nodeType === Node.ARRAY_NODE;
  if (!isArrayNode) {
    throw new Error('Input value is not an array node: ' + JSON.stringify(value));
  }
}

value;