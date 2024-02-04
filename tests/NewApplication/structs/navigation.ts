// Navigation types
type NavigationType = "sidebar" | "appbar" | "breadcrumb";

// Define Item and Section structures
interface NavigationItem {
  id?: string;
  title: string;
  to: string;
  regexPath?: string;
  type: NavigationType;
  required: boolean;
  order: number;
  class: string;
  component: string;
}

interface NavigationSection {
  id?: string;
  title?: string;
  items: NavigationItem[];
  type: NavigationType;
  required: boolean;
  order: number;
  class: string;
}
