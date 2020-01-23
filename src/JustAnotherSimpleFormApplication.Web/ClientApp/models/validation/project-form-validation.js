import Validator from '../../helpers/validator';

export default function getValidator() {
    return new Validator()
        .add('name', (model, errors) => {
            if (!model.name)
                errors.push('Please specify Project Name');
        })
        .add('projectType', (model, errors) => {
            if (model.projectType == null)
                errors.push('Please specify Project Type');
        })
        .add('contractStartDate', (model, errors) => {
            if (model.contractStartDate == null)
                errors.push('Please specify Contract Start Date');
            else if (model.contractStartDate > model.contractEndDate)
                errors.push('Contract Start Date cannot be greater than Contract End Date');
        })
        .add('contractEndDate', (model, errors) => {
            if (model.contractEndDate == null)
                errors.push('Please specify Contract End Date');
        })
        .add('paymentType', (model, errors) => {
            if (model.paymentType == null)
                errors.push('Please specify Payment Type');
        });
}