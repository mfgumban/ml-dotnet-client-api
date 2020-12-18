'use strict';

var value;

if (value != null) {
  const isJsonNode = value instanceof Node && value.nodeType === Node.DOCUMENT_NODE;
  if (!isJsonNode) {
    throw new Error('Input value is not a document node: ' + JSON.stringify(value));
  }
}

value;