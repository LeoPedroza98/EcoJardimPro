export interface IMenuItem {
    name: string;
    params?: any;
    path: string;
    label: string;
    icon: string;
    children?: Array<IMenuItem>;
    relatedRoutes?: Array<string>;
    roles: Array<string>;
    permissions: Array<string>;
}

const items: Array<IMenuItem> = [
    {
        name: 'home',
        path: '/home',
        label: 'Home',
        icon: 'mdi-home-outline',
        roles: [
        ],
        permissions: []
    },
    {
        name: 'clientes',
        path: '/clientes',
        label: 'Clientes',
        icon: 'mdi-account-group-outline',
        relatedRoutes: [
            'pacientesForm',
            'pacientesFormUpdate',
            'pacientesFormView',
        ],
        roles: [

        ],
        permissions: []
    },
    {
        name: 'projetos',
        path: '/projetos',
        label: 'Projetos',
        icon: 'mdi-handshake',
        relatedRoutes: [
        ],
        roles: [
        ],
        permissions: []
    },
]

export default items;