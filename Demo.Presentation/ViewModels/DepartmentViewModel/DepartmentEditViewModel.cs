﻿namespace Demo.Presentation.ViewModels.DepartmentViewModel
{
    public class DepartmentEditViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } =string.Empty;
        public string? Description { get; set; }
        public DateOnly DateOfcreation { get; set; }
    }
}
