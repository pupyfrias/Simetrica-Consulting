export interface TaskUpdateDto {
  title: string;
  description: string;
  statusId: number;
  dueDate: Date;
  priorityId: number;
  projectId?: number;
}
