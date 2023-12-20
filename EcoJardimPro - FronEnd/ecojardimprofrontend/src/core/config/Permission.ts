import permissions, { IPermission } from "./PermissionModel";

export function parsePermissions(hex: string | undefined): string[] {
  // Verifique se hex está definido
  if (hex === undefined) {
    console.error("Hex value is undefined.");
    return [];
  }

  const result: string[] = [];

  let aux: string | undefined = hex.replace('H4-', '');

  // Verifique se aux está definido antes de entrar no loop
  while (aux !== undefined && aux.length) {
    const code = aux.slice(0, 4);

    const permission = permissions.find((item: IPermission) => item.code === code);

    if (permission) {
      result.push(permission.name);
    }

    aux = aux.slice(4);
  }

  return result;
}

