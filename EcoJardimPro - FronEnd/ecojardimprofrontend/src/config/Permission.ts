import permissions, { IPermission } from '@/config/PermissionsModel'

export function parsePermissions(hex: string): string[] {
  const result: string[] = [];

  let aux = hex.replace('H4-', '');

  while (aux.length) {
    const code = aux.slice(0, 4);

    const permission = permissions.find((item: IPermission) => item.code === code);

    if (permission) {
      result.push(permission.name);
    }

    aux = aux.slice(4);
  }

  return result;
}
