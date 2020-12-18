'use strict';

var value;

if (value != null) {
  const isDocNode = value instanceof Node && value.nodeType === Node.OBJECT_NODE;
  if (!isDocNode) {
    throw new Error('Input value is not a document node: ' + JSON.stringify(value));
  }
}

value;