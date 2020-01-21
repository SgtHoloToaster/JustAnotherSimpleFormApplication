import fetch from 'isomorphic-fetch';
import { serialize } from '../helpers/json-serializer';

export default class BaseApiClient {
    static async fetch(url, method, body, queryParameters) {
        function toQuery(queryParameters) {
            const queryParts = [];
            for (let key in queryParameters)
                queryParts.push(`${key}=${queryParameters[key]}`);

            var query = queryParts.join('&');
            return query ? '?' + query : query;
        }

        if (queryParameters)
            url += toQuery(queryParameters);

        const parameters = {
            method,
            headers: {
                'Content-Type': 'application/json'
            }
        };

        if (method !== 'GET')
            parameters.body = serialize(body);

        return fetch(url, parameters);
    }
}