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
    }
]

export default items;