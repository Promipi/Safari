import { Menu } from "@/types/menu";

const menuData: Menu[] = [
  {
    id: 1,
    title: "Home",
    path: "/",
    newTab: false,
  },
  {
    id: 2,
    title: "Nosotros",
    path: "/about",
    newTab: false,
  },
  {
    id: 33,
    title: "Servicios",
    path: "/blog",
    newTab: false,
  },
  {
    id: 3,
    title: "Contacto",
    path: "/contact",
    newTab: false,
  },
  {
    id: 4,
    title: "Otros",
    newTab: false,
    submenu: [
      {
        id: 44,
        title: "Cronograma de Eventos",
        path: "/blog-sidebar",
        newTab: false,
      }

    ],
  },
];
export default menuData;
