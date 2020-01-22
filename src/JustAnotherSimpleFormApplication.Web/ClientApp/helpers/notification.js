import Noty from 'noty';
import 'noty/lib/noty.css';

export default class Notification {
    static success(text) {
        new Noty({
            text,
            theme: 'bootstrap-v4',
            type: 'success',
            layout: 'bottomRight',
            timeout: 2000
        }).show();
    }
}