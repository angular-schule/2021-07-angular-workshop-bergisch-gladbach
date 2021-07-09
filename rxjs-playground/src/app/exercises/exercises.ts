import { Exercises } from './types';

export const exercisesList: Exercises = [
    { name: 'Creating Observables', folder: 'creating' },
    { name: 'Window resize: Observables from events', folder: 'fromevent' },
    { name: 'Game Score: scan and reduce', folder: 'game-score' },
    { name: 'Multicasting with Subjects', folder: 'multicast' },
    { name: 'Error handling', folder: 'error-handling' },
    { name: 'How to unsubscribe and avoid memory leaks', folder: 'unsubscribe' },
    { name: 'Chat: Merging Observables', folder: 'chat' },
    { name: 'Higher Order Observables with concatMap, mergeMap, switchMap, exhaustMap', folder: 'higherorder' },
    { name: 'Drag and drop', folder: 'dragdrop' },
    { name: 'Rate Limiting: debounce, throttle, audit and sample', folder: 'ratelimiting' },
    { name: 'Stock exchange: Use values from other Observables', folder: 'stock' },
    { name: 'Automatic subscriptions with the AsyncPipe', folder: 'asyncpipe' },
    { name: 'Typeahead search', folder: 'typeahead' }
];
