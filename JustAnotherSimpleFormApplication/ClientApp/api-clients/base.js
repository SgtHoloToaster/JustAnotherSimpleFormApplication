import fetch from 'isomorphic-fetch';

export default class BaseApiClient {
    static async fetch(url, method, body) {
        return fetch(url, {
            method,
            body
        });
    }
}