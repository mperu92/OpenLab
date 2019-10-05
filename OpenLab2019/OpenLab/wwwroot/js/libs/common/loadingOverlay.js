import $ from 'jquery';

export function showLoadingOverlay(block) {
 $('#js-loading').addClass(block ? 'block' : 'loading');
}

export function hideLoadingOverlay() {
 $('#js-loading').removeClass('block').removeClass('loading');
}

export default function setupLoadingOverlay() {
 // L'evento viene lanciato solo quando si clicca sulla classe seguente
 $('.js-loading-overlay').on('click', (evt) => {
  // Solo se viene cliccato il tasto sinistro del mouse faccio partire l'animazione di caricamento
  // Diversamente se viene cliccato il tasto centrale non fa partire l'animazione
  if (evt.which === 1) {
   showLoadingOverlay(true);
  }
 });
}
