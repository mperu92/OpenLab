/* eslint-disable no-unused-vars */
/* eslint-disable no-console */
let swPath = '';
if (process.env.NODE_ENV === 'production') {
  swPath = '../../../dist/assets';
} else if (process.env.NODE_ENV === 'development') {
  swPath = '../../../dist/assets/development';
}
const APS = 'BObbqWvZTfcE3ae5ISuIfXOAIrL0wyAA-lGHU-3tS-lPKxL4xbgHbn--hlg8oe6Hiz77tfSIXx8apbawqgcqHQg';

const urlB64ToUint8Array = (base64String) => {
  const padding = '='.repeat((4 - (base64String.length % 4)) % 4);
  const base64 = (base64String + padding).replace(/-/g, '+').replace(/_/g, '/');
  const rawData = atob(base64);
  const outputArray = new Uint8Array(rawData.length);

  for (let i = 0; i < rawData.length; i++) {
    outputArray[i] = rawData.charCodeAt(i);
  }

  return outputArray;
};

export default function setServiceWorker() {
    if ('serviceWorker' in navigator) {
      window.addEventListener('load', () => {
        navigator.serviceWorker.register(`${swPath}/sw.js`)
        .then((registration) => {
          console.log('SW registered');
          registration.pushManager.subscribe({
            userVisibleOnly: true,
            applicationServerKey: urlB64ToUint8Array(APS),
          });
          if (Notification.permission === 'granted') {
            // navigator.serviceWorker.getRegistration().then(function(reg) {
            //   reg.showNotification('Hello world!');
            // });
            const options = {
              body: 'A la Torres!',
            };
            registration.showNotification('Zi Vidì!', options);
          }
        }).catch(() => {
          console.log('SW registration failed');
        });
      });
    }
}
