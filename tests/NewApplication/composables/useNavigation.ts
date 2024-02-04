export const useNavigation = (type: NavigationType, flattenItems = false) => {
  const store = useNavigationStore();

  const navigationItems = computed(() => {
    let sections = store.computedSections
      .filter((section) => section.type === type)
      .sort((a, b) => a.order - b.order);

    if (flattenItems) {
      return sections.flatMap((section) => section.items);
    } else {
      return sections;
    }
  });

  return { navigationItems };
};
