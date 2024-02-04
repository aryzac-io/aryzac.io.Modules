import type NavigationSection from "@/structs/navigation";
import type NavigationItem from "@/structs/navigation";

export const useNavigationStore = defineStore("navigation-store", () => {
  const sections = reactive<NavigationSection[]>([]);
  const items = reactive<NavigationItem[]>([]);

  // Generate a unique ID
  const generateId = () => {
    let uniqueId;
    do {
      uniqueId = Math.random().toString(36).substring(2, 9);
    } while (!isUniqueId(uniqueId));
    return uniqueId;
  };

  // Check for unique ID
  const isUniqueId = (id: string) => {
    return (
      !sections.some((section) => section.id === id) &&
      !items.some((item) => item.id === id)
    );
  };

  // Method to add a new section
  const addSection = (section: NavigationSection) => {
    section.id = section.id || generateId();
    if (!isUniqueId(section.id)) {
      throw new Error(`Duplicate ID detected: ${section.id}`);
    }

    if (section.items && section.items.length > 0) {
      section.items.forEach((item) => {
        item.sectionId = section.id; // Link item to the section
        item.type = section.type;
        addItemToSection(section.id, item); // Add item using the addItem method
      });
      delete section.items; // Optionally clear items from section to avoid duplication
    }

    sections.push(section);
    return section;
  };

  // Method to remove a section by ID
  const removeSection = (sectionId: string) => {
    const sectionIndex = sections.findIndex((s) => s.id === sectionId);
    if (sectionIndex !== -1) {
      sections.splice(sectionIndex, 1); // Remove the section
      // Remove related items
      const itemIndicesToRemove = items
        .map((item, index) => (item.sectionId === sectionId ? index : -1))
        .filter((index) => index !== -1)
        .reverse(); // Reverse to prevent index shifting issues

      itemIndicesToRemove.forEach((index) => {
        items.splice(index, 1);
      });
    }
  };

  // Method to add an item to a section
  const addItemToSection = (sectionId: string, item: NavigationItem) => {
    // Check if the section exists
    const sectionExists = sections.some((section) => section.id === sectionId);
    if (!sectionExists) {
      throw new Error(`Section with ID ${sectionId} does not exist.`);
    }

    // Assign a unique ID to the item if it doesn't have one
    item.id = item.id || generateId();
    if (!isUniqueId(item.id)) {
      throw new Error(`Duplicate ID detected: ${item.id}`);
    }

    // Set the sectionId for the item
    item.sectionId = sectionId;

    // Add the item to the items array
    items.push(item);
    return item;
  };

  // Method to remove an item
  const removeItem = (itemId: string) => {
    const index = items.findIndex((i) => i.id === itemId);
    if (index !== -1) {
      items.splice(index, 1);
    }
  };

  // Method to clear all sections, with an option to keep required items
  const clearSections = (includeRequired: boolean = false) => {
    if (!includeRequired) {
      // Filter out non-required items
      items.splice(0, items.length, ...items.filter((item) => item.required));
      // Filter out non-required sections
      sections.splice(
        0,
        sections.length,
        ...sections.filter((section) => section.required)
      );
    } else {
      // Clear all items and sections
      items.splice(0, items.length);
      sections.splice(0, sections.length);
    }
  };

  // Get the active navigation item
  const isActiveItem = (item: NavigationItem): boolean => {
    const route = useRoute();
    const router = useRouter();

    // Direct match
    if (route.fullPath === router.resolve(item.to).fullPath) {
      return true;
    }

    // Regex match
    if (item.regexPath && new RegExp(item.regexPath).test(route.fullPath)) {
      return true;
    }

    return false;
  };

  const getActiveItem = (
    navigationType: NavigationType
  ): NavigationItem | null => {
    let activeItem: NavigationItem | null = null;
    let highestRank = -1;

    for (const item of items) {
      // Check if the item belongs to the specified navigation type
      if (item.type.includes(navigationType) && isActiveItem(item)) {
        const rank = item.regexPath ? item.regexPath.length : 0;
        if (rank > highestRank) {
          highestRank = rank;
          activeItem = item;
        }
      }
    }

    return activeItem;
  };

  // Computed property to reconstruct sections with items
  const computedSections = computed(() =>
    sections.map((section) => ({
      ...section,
      items: items.filter((item) => item.sectionId === section.id),
    }))
  );

  return {
    // State
    sections,
    items,

    // Actions and methods
    addSection,
    removeSection,
    addItemToSection,
    removeItem,
    clearSections,
    getActiveItem,

    // Computed properties
    computedSections,
  };
});
