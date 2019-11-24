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
        .then(() => {
          console.log('SW registered');
        }).catch(() => {
          console.log('SW registration failed');
        });
      });
    }
}
