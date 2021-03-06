﻿import $ from 'jquery';
import 'bootstrap';

import '../scss/main.scss';

// backoffice
import configDashboardPage from './libs/configpages/backend/dashboard';

// frontend
import configDashboardPageFront from './libs/configpages/frontend/dashboard';

// commons
import setServiceWorker from './libs/common/setServiceWorker';
import loadingOverlay from './libs/common/loadingOverlay';

const OpenLabJsClient = {
  common: {
    init() {
      // HACK
      setServiceWorker();
      loadingOverlay();
    },
    finalize() {
      // called only from page with main-content/data-controller set
    },
  },
  // backoffice
  dashboardPage: {
    init() {
      configDashboardPage();
    },
  },
  // frontend
  dashboardPageFrontend: {
    init() {
      configDashboardPageFront();
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
    const mainContent = document.getElementById('ol-controller');
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
