export default defineNuxtRouteMiddleware((to, from) => {
  const { clearSections } = useNavigationStore();

  clearSections();
});
