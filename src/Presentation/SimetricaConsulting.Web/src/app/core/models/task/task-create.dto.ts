export interface TaskCreateDto {
  title: string;
  description: string;
  statusId: number;
  dueDate: Date;
  priorityId: number;
  userId: number;
  projectId?: number;
}
