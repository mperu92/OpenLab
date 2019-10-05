/* eslint-disable */
import $ from 'jquery';
import 'bootstrap';

import '../scss/main.scss';

// commons
import loadingOverlay from './libs/common/loadingOverlay';

const OpenLabJsClient = {
  common: {
    init() {
      // HACK
      loadingOverlay();
    },
    finalize() {
      // called only from page with main-content/data-controller set
    },
  },
};

const UTIL = {
  fire(func, funcname = 'init') {
    const namespace = OpenLabJsClient;
    if (func !== '' && namespace[func] && typeof namespace[func][funcname] === 'function') {
      namespace[func][funcname]();
    }
  },
  loadEvents() {
    // hit up common first.
    UTIL.fire('common');
    const mainContent = document.getElementById('openlab-frontend');
    if (mainContent === 'undefined' || mainContent === null) {
      return;
    }
    const controller = mainContent.getAttribute('data-controller');
    if (controller !== '') {
      UTIL.fire(controller);
    }
    UTIL.fire('common', 'finalize');
  },
};

/* eslint-disable func-names, id-length, no-unused-expressions */
$(document).ready(() => {
  UTIL.loadEvents();
});
