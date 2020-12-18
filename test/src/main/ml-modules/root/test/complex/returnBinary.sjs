'use strict';

var value;

if (value != null) {
  if (typeof value !== 'object') {
    throw new Error(`Input value is not an object: ${value}`);
  }
}

value;