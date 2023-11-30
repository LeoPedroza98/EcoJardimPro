import router from '../router';

export default class NavigationHelper {
  public static navigate(name: string) {
    router.push({ name });
  }

  public static navigateToPath(fullPath: string) {
    router.push(fullPath);
  }
  
  public static goBack() {
    router.back();
  }
}
