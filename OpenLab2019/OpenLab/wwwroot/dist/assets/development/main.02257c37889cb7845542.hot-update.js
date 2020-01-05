webpackHotUpdate("main",{

/***/ "./wwwroot/js/libs/redux/actions/newsActions.js":
/*!******************************************************!*\
  !*** ./wwwroot/js/libs/redux/actions/newsActions.js ***!
  \******************************************************/
/*! exports provided: loadNewsListSuccess, createNewsSuccess, updateNewsSuccess, deleteNewsOptimistic, loadNewsList, saveNews, deleteNews */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"loadNewsListSuccess\", function() { return loadNewsListSuccess; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"createNewsSuccess\", function() { return createNewsSuccess; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"updateNewsSuccess\", function() { return updateNewsSuccess; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"deleteNewsOptimistic\", function() { return deleteNewsOptimistic; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"loadNewsList\", function() { return loadNewsList; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"saveNews\", function() { return saveNews; });\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"deleteNews\", function() { return deleteNews; });\n/* harmony import */ var axios__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! axios */ \"./node_modules/axios/index.js\");\n/* harmony import */ var axios__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(axios__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var _actionTypes__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./actionTypes */ \"./wwwroot/js/libs/redux/actions/actionTypes.js\");\n/* harmony import */ var _apiStatusActions__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./apiStatusActions */ \"./wwwroot/js/libs/redux/actions/apiStatusActions.js\");\n/* eslint-disable import/prefer-default-export */\n\n\n\nfunction loadNewsListSuccess(newsList) {\n  return {\n    type: _actionTypes__WEBPACK_IMPORTED_MODULE_1__[\"LOAD_NEWS_SUCCESS\"],\n    newsList: newsList\n  };\n}\nfunction createNewsSuccess(news) {\n  return {\n    type: _actionTypes__WEBPACK_IMPORTED_MODULE_1__[\"CREATE_NEWS_SUCCESS\"],\n    news: news\n  };\n}\nfunction updateNewsSuccess(news) {\n  return {\n    type: _actionTypes__WEBPACK_IMPORTED_MODULE_1__[\"UPDATE_NEWS_SUCCESS\"],\n    news: news\n  };\n}\nfunction deleteNewsOptimistic(news) {\n  return {\n    type: _actionTypes__WEBPACK_IMPORTED_MODULE_1__[\"DELETE_NEWS_OPTIMISTIC\"],\n    news: news\n  };\n}\nfunction loadNewsList(online) {\n  return function (dispatch) {\n    dispatch(Object(_apiStatusActions__WEBPACK_IMPORTED_MODULE_2__[\"beginApiCall\"])());\n    axios__WEBPACK_IMPORTED_MODULE_0___default.a.post('/api/NewsApi/getNewsList', {\n      online: online\n    }).then(function (_ref) {\n      var data = _ref.data;\n\n      if (data && data !== undefined && data !== null) {\n        dispatch(loadNewsListSuccess(data));\n      } else {\n        var error = Error.apply('error while loading news list.');\n        dispatch(Object(_apiStatusActions__WEBPACK_IMPORTED_MODULE_2__[\"apiCallError\"])(error));\n        throw error;\n      }\n    })[\"catch\"](function (error) {\n      dispatch(Object(_apiStatusActions__WEBPACK_IMPORTED_MODULE_2__[\"apiCallError\"])(error));\n      throw error;\n    });\n  };\n} // thunk\n\nfunction saveNews(news) {\n  return function (dispatch) {\n    // , getState\n    dispatch(Object(_apiStatusActions__WEBPACK_IMPORTED_MODULE_2__[\"beginApiCall\"])());\n    return axios__WEBPACK_IMPORTED_MODULE_0___default.a.post('/api/NewsApi/createUpdateNews', {\n      news: news\n    }).then(function (_ref2) {\n      var respNews = _ref2.data.respNews;\n\n      if (respNews && respNews !== undefined && respNews !== null) {\n        if (news.id) {\n          dispatch(updateNewsSuccess(respNews));\n        } else {\n          dispatch(createNewsSuccess(respNews));\n        }\n      } else {\n        var error = Error.apply('error while creating - updating news.');\n        dispatch(Object(_apiStatusActions__WEBPACK_IMPORTED_MODULE_2__[\"apiCallError\"])(error));\n        throw error;\n      }\n    })[\"catch\"](function (error) {\n      dispatch(Object(_apiStatusActions__WEBPACK_IMPORTED_MODULE_2__[\"apiCallError\"])(error));\n      throw error;\n    });\n  };\n} // thunk\n\nfunction deleteNews(news) {\n  return function (dispatch) {\n    // Doin' optimisic delete, so not dispatching begin/end api call\n    // actions, or apiCallError action since we're not showing the loading status for this.\n    dispatch(deleteNewsOptimistic(news));\n    return axios__WEBPACK_IMPORTED_MODULE_0___default.a.post('/api/NewsApi/deleteNews', {\n      news: news\n    }).then(function (_ref3) {\n      var deleted = _ref3.data.deleted;\n\n      if (!deleted || deleted === undefined || deleted === null) {\n        var error = Error.apply('error while deleting news.'); // dispatch(apiCallError(error));\n\n        throw error;\n      }\n    })[\"catch\"](function (error) {\n      // dispatch(apiCallError(error));\n      throw error;\n    });\n  };\n}//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiLi93d3dyb290L2pzL2xpYnMvcmVkdXgvYWN0aW9ucy9uZXdzQWN0aW9ucy5qcy5qcyIsInNvdXJjZXMiOlsid2VicGFjazovLy8uL3d3d3Jvb3QvanMvbGlicy9yZWR1eC9hY3Rpb25zL25ld3NBY3Rpb25zLmpzPzNkNDkiXSwic291cmNlc0NvbnRlbnQiOlsiLyogZXNsaW50LWRpc2FibGUgaW1wb3J0L3ByZWZlci1kZWZhdWx0LWV4cG9ydCAqL1xyXG5pbXBvcnQgYXhpb3MgZnJvbSAnYXhpb3MnO1xyXG5pbXBvcnQgKiBhcyB0eXBlcyBmcm9tICcuL2FjdGlvblR5cGVzJztcclxuaW1wb3J0IHsgYmVnaW5BcGlDYWxsLCBhcGlDYWxsRXJyb3IgfSBmcm9tICcuL2FwaVN0YXR1c0FjdGlvbnMnO1xyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGxvYWROZXdzTGlzdFN1Y2Nlc3MobmV3c0xpc3QpIHtcclxuICAgIHJldHVybiB7IHR5cGU6IHR5cGVzLkxPQURfTkVXU19TVUNDRVNTLCBuZXdzTGlzdCB9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gY3JlYXRlTmV3c1N1Y2Nlc3MobmV3cykge1xyXG4gICAgcmV0dXJuIHsgdHlwZTogdHlwZXMuQ1JFQVRFX05FV1NfU1VDQ0VTUywgbmV3cyB9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gdXBkYXRlTmV3c1N1Y2Nlc3MobmV3cykge1xyXG4gICAgcmV0dXJuIHsgdHlwZTogdHlwZXMuVVBEQVRFX05FV1NfU1VDQ0VTUywgbmV3cyB9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZGVsZXRlTmV3c09wdGltaXN0aWMobmV3cykge1xyXG4gICAgcmV0dXJuIHsgdHlwZTogdHlwZXMuREVMRVRFX05FV1NfT1BUSU1JU1RJQywgbmV3cyB9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gbG9hZE5ld3NMaXN0KG9ubGluZSkge1xyXG4gICAgcmV0dXJuIChkaXNwYXRjaCkgPT4ge1xyXG4gICAgICAgIGRpc3BhdGNoKGJlZ2luQXBpQ2FsbCgpKTtcclxuICAgICAgICBheGlvcy5wb3N0KCcvYXBpL05ld3NBcGkvZ2V0TmV3c0xpc3QnLCB7IG9ubGluZSB9KVxyXG4gICAgICAgIC50aGVuKCh7IGRhdGEgfSkgPT4ge1xyXG4gICAgICAgICAgICBpZiAoZGF0YSAmJiBkYXRhICE9PSB1bmRlZmluZWQgJiYgZGF0YSAhPT0gbnVsbCkge1xyXG4gICAgICAgICAgICAgICAgZGlzcGF0Y2gobG9hZE5ld3NMaXN0U3VjY2VzcyhkYXRhKSk7XHJcbiAgICAgICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgICAgICBjb25zdCBlcnJvciA9IEVycm9yLmFwcGx5KCdlcnJvciB3aGlsZSBsb2FkaW5nIG5ld3MgbGlzdC4nKTtcclxuICAgICAgICAgICAgICAgIGRpc3BhdGNoKGFwaUNhbGxFcnJvcihlcnJvcikpO1xyXG4gICAgICAgICAgICAgICAgdGhyb3cgZXJyb3I7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9KVxyXG4gICAgICAgIC5jYXRjaCgoZXJyb3IpID0+IHtcclxuICAgICAgICAgICAgZGlzcGF0Y2goYXBpQ2FsbEVycm9yKGVycm9yKSk7XHJcbiAgICAgICAgICAgIHRocm93IGVycm9yO1xyXG4gICAgICAgIH0pO1xyXG4gICAgfTtcclxufVxyXG5cclxuLy8gdGh1bmtcclxuZXhwb3J0IGZ1bmN0aW9uIHNhdmVOZXdzKG5ld3MpIHtcclxuICAgIHJldHVybiAoZGlzcGF0Y2gpID0+IHsgLy8gLCBnZXRTdGF0ZVxyXG4gICAgICAgIGRpc3BhdGNoKGJlZ2luQXBpQ2FsbCgpKTtcclxuICAgICAgICByZXR1cm4gYXhpb3MucG9zdCgnL2FwaS9OZXdzQXBpL2NyZWF0ZVVwZGF0ZU5ld3MnLCB7IG5ld3MgfSlcclxuICAgICAgICAudGhlbigoeyBkYXRhOiB7IHJlc3BOZXdzIH0gfSkgPT4ge1xyXG4gICAgICAgICAgICBpZiAocmVzcE5ld3MgJiYgcmVzcE5ld3MgIT09IHVuZGVmaW5lZCAmJiByZXNwTmV3cyAhPT0gbnVsbCkge1xyXG4gICAgICAgICAgICAgICAgaWYgKG5ld3MuaWQpIHtcclxuICAgICAgICAgICAgICAgICAgICBkaXNwYXRjaCh1cGRhdGVOZXdzU3VjY2VzcyhyZXNwTmV3cykpO1xyXG4gICAgICAgICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgICAgICAgICBkaXNwYXRjaChjcmVhdGVOZXdzU3VjY2VzcyhyZXNwTmV3cykpO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgY29uc3QgZXJyb3IgPSBFcnJvci5hcHBseSgnZXJyb3Igd2hpbGUgY3JlYXRpbmcgLSB1cGRhdGluZyBuZXdzLicpO1xyXG4gICAgICAgICAgICAgICAgZGlzcGF0Y2goYXBpQ2FsbEVycm9yKGVycm9yKSk7XHJcbiAgICAgICAgICAgICAgICB0aHJvdyBlcnJvcjtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH0pXHJcbiAgICAgICAgLmNhdGNoKChlcnJvcikgPT4ge1xyXG4gICAgICAgICAgICBkaXNwYXRjaChhcGlDYWxsRXJyb3IoZXJyb3IpKTtcclxuICAgICAgICAgICAgdGhyb3cgZXJyb3I7XHJcbiAgICAgICAgfSk7XHJcbiAgICB9O1xyXG59XHJcblxyXG4vLyB0aHVua1xyXG5leHBvcnQgZnVuY3Rpb24gZGVsZXRlTmV3cyhuZXdzKSB7XHJcbiAgICByZXR1cm4gKGRpc3BhdGNoKSA9PiB7XHJcbiAgICAgICAgLy8gRG9pbicgb3B0aW1pc2ljIGRlbGV0ZSwgc28gbm90IGRpc3BhdGNoaW5nIGJlZ2luL2VuZCBhcGkgY2FsbFxyXG4gICAgICAgIC8vIGFjdGlvbnMsIG9yIGFwaUNhbGxFcnJvciBhY3Rpb24gc2luY2Ugd2UncmUgbm90IHNob3dpbmcgdGhlIGxvYWRpbmcgc3RhdHVzIGZvciB0aGlzLlxyXG4gICAgICAgIGRpc3BhdGNoKGRlbGV0ZU5ld3NPcHRpbWlzdGljKG5ld3MpKTtcclxuICAgICAgICByZXR1cm4gYXhpb3MucG9zdCgnL2FwaS9OZXdzQXBpL2RlbGV0ZU5ld3MnLCB7IG5ld3MgfSlcclxuICAgICAgICAudGhlbigoeyBkYXRhOiB7IGRlbGV0ZWQgfSB9KSA9PiB7XHJcbiAgICAgICAgICAgIGlmICghZGVsZXRlZCB8fCBkZWxldGVkID09PSB1bmRlZmluZWQgfHwgZGVsZXRlZCA9PT0gbnVsbCkge1xyXG4gICAgICAgICAgICAgICAgY29uc3QgZXJyb3IgPSBFcnJvci5hcHBseSgnZXJyb3Igd2hpbGUgZGVsZXRpbmcgbmV3cy4nKTtcclxuICAgICAgICAgICAgICAgIC8vIGRpc3BhdGNoKGFwaUNhbGxFcnJvcihlcnJvcikpO1xyXG4gICAgICAgICAgICAgICAgdGhyb3cgZXJyb3I7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9KVxyXG4gICAgICAgIC5jYXRjaCgoZXJyb3IpID0+IHtcclxuICAgICAgICAgICAgLy8gZGlzcGF0Y2goYXBpQ2FsbEVycm9yKGVycm9yKSk7XHJcbiAgICAgICAgICAgIHRocm93IGVycm9yO1xyXG4gICAgICAgIH0pO1xyXG4gICAgfTtcclxufVxyXG4iXSwibWFwcGluZ3MiOiJBQUFBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBQ0E7QUFDQTtBQUNBO0FBRUE7QUFDQTtBQUFBO0FBQUE7QUFBQTtBQUNBO0FBRUE7QUFDQTtBQUFBO0FBQUE7QUFBQTtBQUNBO0FBRUE7QUFDQTtBQUFBO0FBQUE7QUFBQTtBQUNBO0FBRUE7QUFDQTtBQUFBO0FBQUE7QUFBQTtBQUNBO0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFBQTtBQUFBO0FBQ0E7QUFDQTtBQUFBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFFQTtBQUNBO0FBQUE7QUFDQTtBQUNBO0FBQUE7QUFBQTtBQUNBO0FBQ0E7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFBQTtBQUFBO0FBQ0E7QUFDQTtBQUFBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EiLCJzb3VyY2VSb290IjoiIn0=\n//# sourceURL=webpack-internal:///./wwwroot/js/libs/redux/actions/newsActions.js\n");

/***/ })

})