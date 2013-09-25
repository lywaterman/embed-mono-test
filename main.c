#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <assert.h>

int main (int argc, char *argv) {

	mono_set_dirs("/usr/local/lib", "/etc");

	mono_config_parse(NULL);

	MonoDomain *domain = mono_jit_init_version("root", "v4.0.30319");

	MonoAssembly *assembly = mono_domain_assembly_open(domain, "root.exe");

	MonoImage *image = mono_assembly_get_image(assembly);

	if (!assembly)
		assert(0);

	if (!image)
		assert(0);

	MonoClass * MyWorld = mono_class_from_name(image, "", "MyWorld");

	if (!MyWorld)
		assert(0);

	MonoMethod* run_method = mono_class_get_method_from_name(MyWorld, "Run", 1);

	MonoObject* myworld = mono_object_new(domain, MyWorld);
    mono_runtime_object_init(myworld);

	if (!myworld) 
		assert(0);

	if (!run_method) 
		assert(0);

	MonoString* string = mono_string_new(domain, "using System;");

	void* args[1];

	args[0] = string;

	mono_runtime_invoke(run_method, myworld, args, NULL);
}
