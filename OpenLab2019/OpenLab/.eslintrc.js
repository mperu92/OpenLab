const OFF = 0, WARN = 1, ERROR = 2;
module.exports = {
  "extends": ["airbnb"],
  "parser": "babel-eslint",
  "parserOptions": {
    "ecmaVersion": 6,
    "sourceType": "module",
    "allowImportExportEverywhere": false,
    "codeFrame": false,
    "ecmaFeatures": {
      globalReturn: true,
      impliedStrict: true,
      jsx: true,
      arrowFunction: true,
      globalJsData: true,
     }
  },
  "plugins": ["react"],
  "env": {
    "es6": true,
    "browser": true
  },
  "globals": {
    "VERSION": true,
    "__DEV__": true,
    "__STAGE__": true,
    "__PRERELEASE__": true,
    "tinyMCE": true,
    "google": true,
    "enquire": true,
    "__globalJsData": true,
    "videojs": true
  },
 "rules":{
    "react/jsx-filename-extension": [WARN, { "extensions": [".js", ".jsx"] }],
    "react/jsx-indent": [OFF],
    "linebreak-style": [OFF],
    "template-curly-spacing" : [OFF],
    "indent" : [OFF],
    "jsx-a11y/anchor-is-valid" : [OFF],
    "max-len": [OFF],
    "no-debugger": [WARN],
    "react/no-danger": [OFF],
    "no-tabs": [OFF],
    "react/no-unused-state": [WARN],
    "react/no-unused-prop-types": [WARN],
    "import/no-extraneous-dependencies": [OFF],
    "no-unused-vars": [WARN],
    "no-unused-expressions": [WARN]
  }
};