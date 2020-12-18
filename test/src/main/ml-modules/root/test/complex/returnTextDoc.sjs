'use strict';

var value;

if (value != null) {
  const isNode = value instanceof Node;
  if (!isNode) {
    throw new Error('Input value is not a node: ' + JSON.stringify(value));
  }
}

value;