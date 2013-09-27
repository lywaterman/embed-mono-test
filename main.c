#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/object.h>
#include <assert.h>

void call_print(MonoDomain* domain, MonoImage* image, const char* str) {
	MonoClass * MyWorld = mono_class_from_name(image, "", "MyWorld");

	if (!MyWorld)
		assert(0);

	MonoMethod* run_method = mono_class_get_method_from_name(MyWorld, "println", 1);

	void* args[1];
	args[0] = mono_string_new(domain, str);
	mono_runtime_invoke(run_method, NULL, args, NULL);
}

void call_printInt(MonoDomain* domain, MonoImage* image, int32_t str) {
	MonoClass * MyWorld = mono_class_from_name(image, "", "MyWorld");

	if (!MyWorld)
		assert(0);

	MonoMethod* run_method = mono_class_get_method_from_name(MyWorld, "printlnInt", 1);

	void* args[1];
	args[0] = &str;
	mono_runtime_invoke(run_method, NULL, args, NULL);
}

MonoObject* call_func(MonoDomain* domain, MonoImage* image, const char* str) {
	MonoClass * MyWorld = mono_class_from_name(image, "", "MyWorld");

	if (!MyWorld)
		assert(0);

	MonoMethod* run_method = mono_class_get_method_from_name(MyWorld, "call", 1);

	void* args[1];
	args[0] = mono_string_new(domain, str);
	return mono_runtime_invoke(run_method, NULL, args, NULL);
}

MonoObject* call(MonoClass* clz, const char* mname, int arg_count, void** args) {
	MonoMethod* run_method = mono_class_get_method_from_name(clz, mname, arg_count);
	
	return mono_runtime_invoke(run_method, NULL, args, NULL);
}


void main (int argc, char *argv) {

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

	MonoMethod* run_method = mono_class_get_method_from_name(MyWorld, "root", 1);

	//MonoObject* myworld = mono_object_new(domain, MyWorld);
    //mono_runtime_object_init(myworld);

	//if (!myworld) 
	//	assert(0);

	if (!run_method) 
		assert(0);

	MonoClass *ht_class = mono_class_from_name_case(image, "", "MyHashtable");

	MonoObject * obj = mono_object_new(domain, ht_class);
    mono_runtime_object_init(obj);

	if (!obj) 
		assert(0);

	void* args[1];

	args[0] = obj;

	mono_runtime_invoke(run_method, NULL, args, NULL);

	MonoObject * array = call_func(domain, image, "game_object");
	//MonoObject * array = call_func(domain, image, "GameFunc.fib(40);");
	//
	
	MonoClass * cls1 = mono_object_get_class(array);

	int x = 40;
	void* xxx[1];
	xxx[0] = &x; 

	MonoObject* ooo = call(cls1, "fib", 1, xxx);

	call_print(domain, image, mono_class_get_name(mono_object_get_class(ooo)));
	MonoClass * cls = mono_object_get_class(ooo);
	
	if (cls == mono_get_int16_class()) {

	} else if (cls == mono_get_int32_class()) {
		call_print(domain, image, "i am int32");
		
		int32_t p = *(int32_t*)mono_object_unbox(ooo);

		call_printInt(domain, image, p);

	} else if (cls == mono_get_int64_class()) {

	} else if (cls == mono_get_double_class()) {

	} else if (cls == mono_get_string_class()) {

	} else if (cls == mono_get_uint16_class()) {

	} else if (cls == mono_get_uint32_class()) {

	} else if (cls == mono_get_uint64_class()) {

	} else if (cls == mono_get_array_class()) {

	} else if (cls == mono_get_boolean_class()) {
		call_print(domain,image, "i am boolean");
	} else if (cls == mono_get_void_class()) {
		call_print(domain,image, "i am void");
	}



	//MonoString* string = mono_string_new(domain, "using System;");

	//void* args[1];

	//args[0] = string;

	//mono_runtime_invoke(run_method, myworld, args, NULL);
}


