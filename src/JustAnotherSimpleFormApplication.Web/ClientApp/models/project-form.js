export default class ProjectForm {
    constructor(form) {
        form = form || {};
        this.name = form.name;
        this.projectType = form.projectType;
        this.contractStartDate = form.contractStartDate;
        this.contractEndDate = form.contractEndDate;
        this.paymentType = form.paymentType;
        this.isFormerClient = form.isFormerClient;
    }
}