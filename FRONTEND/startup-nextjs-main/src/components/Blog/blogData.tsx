import { Blog } from "@/types/blog";

const blogData: Blog[] = [
  {
    id: 1,
    title: "SAFARI",
    paragraph:
      "Un paseo en auto explorando los diverosos parques nacionales, reservas naturales y áreas protegidas con nuestros guías expertos. Descubre la flora, fauna y la historia detrás de cada lugar.",
    image: "/images/blog/safari.jpg",
    author: {
      name: "Samuyl Joshi",
      image: "/images/blog/author-01.png",
      designation: "Graphic Designer",
    },
    tags: ["creative"],
    publishDate: "2025",
  },
  
  {
    id: 2,
    title: "TREKKING",
    paragraph:
      "Senderos con marcadores de realidad aumentada, podes escanear códigos QR en la naturaleza para obtener información sobre la flora, fauna y la historia del lugar mietras te sumergis en la magia de la naturaleza.",
    image: "/images/blog/trekking.jpg",
    author: {
      name: "Musharof Chy",
      image: "/images/blog/author-02.png",
      designation: "Content Writer",
    },
    tags: ["computer"],
    publishDate: "2025",
  },
  {
    id: 3,
    title: "PASEO CULTURAL",
    paragraph:
      "Ofrcemos un tour culinario por mercados locales, donde los turistas prueban platos tradicionales y compran ingredientes frescos.",
    image: "/images/blog/trekking.jpg",
    author: {
      name: "Lethium Deo",
      image: "/images/blog/author-03.png",
      designation: "Graphic Designer",
    },
    tags: ["design"],
    publishDate: "2025",
  },
];
export default blogData;
