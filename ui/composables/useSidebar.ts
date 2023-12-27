export const useSidebar = () => {
    const sidebarOpen = useState<boolean>('sidebarOpen', () => false);

    const openSidebar = () => {
        sidebarOpen.value = true;
    }
    const closeSidebar = () => {
        sidebarOpen.value = false;
    }

    return { sidebarOpen, openSidebar, closeSidebar };
}