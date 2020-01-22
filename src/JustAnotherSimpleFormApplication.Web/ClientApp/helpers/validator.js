export default class Validator {
    constructor() {
        this.validationResult = {};
        this.validations = {};
    }

    add(fieldName, action) {
        this.validations[fieldName] = action;
        return this;
    }

    validate(model) {
        this.validationResult = {};
        const validateField = fieldName => {
            if (!this.validations[fieldName]) {
                this.validationResult[fieldName] = [];
                return true;
            }

            var errors = [];
            this.validations[fieldName](model, errors);
            this.validationResult[fieldName] = errors;
            return !errors.length;
        };

        var hasErrors = false;
        for (var fieldName in this.validations) {
            if (!validateField(fieldName))
                hasErrors = true;
        }

        return !hasErrors;
    }

    haveErrors() {
        for (var fieldName in this.validationResult) {
            if (this.validationResult[fieldName] && this.validationResult[fieldName].length)
                return true;
        }

        return false;
    }

    getErrors(fieldName) {
        return this.validationResult[fieldName] || [];
    }
}