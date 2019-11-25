importScripts("precache-manifest.9c36aaf5fde49d9231f846623beee12a.js", "https://storage.googleapis.com/workbox-cdn/releases/4.3.1/workbox-sw.js");

/* eslint-disable */
workbox.core.skipWaiting();
workbox.core.clientsClaim();

workbox.routing.registerRoute(
  new RegExp('https://localhost:44357'),
  new workbox.strategies.StaleWhileRevalidate()
);

self.addEventListener('push', (event) => {
  const title = 'OpenLab';
  const options = {
    body: event.data.text()
  };
  event.waitUntil(self.registration.showNotification(title, options));
});

workbox.precaching.precacheAndRoute(self.__precacheManifest);
