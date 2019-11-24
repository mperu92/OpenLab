/* eslint-disable no-unused-vars */
/* eslint-disable no-console */
let swPath = '';
if (process.env.NODE_ENV === 'production') {
  swPath = '../../../dist/assets';
} else if (process.env.NODE_ENV === 'development') {
  swPath = '../../../dist/assets/development';
}

export default function setServiceWorker() {
    if ('serviceWorker' in navigator) {
      window.addEventListener('load', () => {
        navigator.serviceWorker.register(`${swPath}/sw.js`)
        .then((registration) => {
          console.log('SW registered');
          registration.pushManager.subscribe({
            userVisibleOnly: true,
            applicationServerKey: 'BIDybRI_lfBFLjig5wIbOeplyxMHI0QStOVwi-49ttlc9xRJxW7DdI_dSSi24OjHPor4UdI5O3_p5FDfb1vb19I',
          });
          if (Notification.permission === 'granted') {
            // navigator.serviceWorker.getRegistration().then(function(reg) {
            //   reg.showNotification('Hello world!');
            // });
            registration.showNotification('Zi Bidì!');
          }
        }).catch(() => {
          console.log('SW registration failed');
        });
      });
    }
}
