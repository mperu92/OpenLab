import React from 'react'; // eslint-disable-line no-unused-vars
import ReactDOM from 'react-dom';

export default function render(component, domId) {
  const domNode = document.getElementById(domId);
  if (domNode) {
    ReactDOM.render(component, domNode);
  }
}
