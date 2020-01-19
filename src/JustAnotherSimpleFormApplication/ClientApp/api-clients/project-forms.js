import BaseApiClient from './base';

export default class ProjectFormsApiClient {
    static async addNew(form) {
        return BaseApiClient.fetch('api/projectForms', 'POST', form);
    }
}