import BaseApiClient from './base';

const url = '/api/projectForms';
export default class ProjectFormsApiClient {
    static async addNew(form) {
        return BaseApiClient.fetch(url, 'POST', form);
    }

    static async getForms(name) {
        const filter = {};
        if (name != undefined)
            filter.name = name;

        return BaseApiClient.fetch(url, 'GET', null, filter);
    }
}