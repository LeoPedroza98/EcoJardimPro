import permissions, { IPermission } from '@/config/PermissionsModel';

export function parsePermissions(hex: string): string[] {
  const result: string[] = [];

  let aux = hex.replace('H4-', '');

  while (aux.length >= 4) {
    const code = aux.slice(0, 4);

    const permission = permissions.find((item: IPermission) => item.code === code);

    if (permission && permission.name) {
      result.push(permission.name);
    }

    aux = aux.slice(4);
  }

  return result;
}
