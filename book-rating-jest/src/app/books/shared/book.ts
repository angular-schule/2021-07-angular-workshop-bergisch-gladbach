export interface Book {
  isbn: string;
  title: string;
  description: string;
  rating: number;
  firstThumbnailUrl: string | null;
  authors: string[];
}
