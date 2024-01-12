export const useNavigationSetup = () => {
  const { sections, addSection, addItemToSection, clearSections } =
    useNavigationStore();

  const setupSectionItem = (type, name, icon, to, required = true) => {
    // Assuming 'type' also represents a unique section id
    const sectionExists = sections.some((section) => section.id === type);
    if (!sectionExists) {
      addSection({
        id: type, // Using type as id for simplicity
        class: getClassForType(type),
        component: type,
        required: true,
        type: type,
      });
    }

    addItemToSection(type, {
      name: name,
      icon: icon,
      to: to,
      required: required,
      type: type,
    });
  };

  const setupSection = (type, component, options = {}, required = true) => {
    addSection({
      id: component,
      component: component,
      required: required,
      type: type,
      ...options,
    });
  };

  const getClassForType = (type) => {
    // Define default classes for each type
    const typeClasses = {
      sidebar: "hidden lg:flex lg:space-x-8",
      appbar: "hidden lg:flex lg:space-x-8",
    };
    return typeClasses[type] || "";
  };

  return { setupSection, setupSectionItem };
};
